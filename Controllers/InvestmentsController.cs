using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sandogh.context;
using Sandogh.Models;

public class InvestmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public InvestmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Investments
    public async Task<IActionResult> Index(int memberId)
    {
        var investments = await _context.Investments
            .Where(i => i.MemberId == memberId)
            .Include(i => i.Member)
            .ToListAsync();

        return View(investments);
    }

    // GET: Investments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var investment = await _context.Investments
            .Include(i => i.Member)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (investment == null)
        {
            return NotFound();
        }

        return View(investment);
    }

    // GET: Investments/Create
    public IActionResult Create()
    {
        ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FullName");
        return View();
    }

    // POST: Investments/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,MemberId,Amount,InvestmentType,InterestRate,StartDate,EndDate,Status,Note")] Investment investment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(investment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { memberId = investment.MemberId });
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FullName", investment.MemberId);
        return View(investment);
    }

    // GET: Investments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var investment = await _context.Investments.FindAsync(id);
        if (investment == null)
        {
            return NotFound();
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FullName", investment.MemberId);
        return View(investment);
    }

    // POST: Investments/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,MemberId,Amount,InvestmentType,InterestRate,StartDate,EndDate,Status,Note")] Investment investment)
    {
        if (id != investment.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(investment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(investment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index), new { memberId = investment.MemberId });
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FullName", investment.MemberId);
        return View(investment);
    }

    // GET: Investments/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var investment = await _context.Investments
            .Include(i => i.Member)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (investment == null)
        {
            return NotFound();
        }

        return View(investment);
    }

    // POST: Investments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var investment = await _context.Investments.FindAsync(id);
        if (investment != null)
        {
            int memberId = investment.MemberId; // گرفتن شناسه عضو
            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { memberId });
        }

        return RedirectToAction(nameof(Index)); // اگر سرمایه‌گذاری پیدا نشد، به صفحه اصلی بروید
    }

    private bool InvestmentExists(int id)
    {
        return _context.Investments.Any(e => e.Id == id);
    }
}
