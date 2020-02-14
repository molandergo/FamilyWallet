using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWallet.Models
{
    public class ExpensesDataAcessLayer
    {
        
            ExpenseDBContext db = new ExpenseDBContext();
            public IEnumerable<ExpenseReport> GetAllExpenses()
            {
                try
                {
                    return db.ExpenseReport.ToList();
                }
                catch
                {
                    throw;
                }
            }
            public IEnumerable<ExpenseReport> GetSearchResult(string searchString)
            {
                List<ExpenseReport> exp = new List<ExpenseReport>();
                try
                {
                    exp = GetAllExpenses().ToList();
                    return exp.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
                }
                catch
                {
                    throw;
                }
            }

            public void AddExpense(ExpenseReport expense)
            {
                try
                {

                    db.ExpenseReport.Add(expense);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }

            public int UpdateExpense(ExpenseReport expense)
            {
                try
                {
                    db.Entry(expense).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    throw;
                }
            }

            public ExpenseReport GetExpenseData(int id)
            {
                try
                {
                    ExpenseReport expense = db.ExpenseReport.Find(id);
                    return expense;
                }
                catch
                {
                    throw;
                }
            }

            public void DeleteExpense(int id)
            {
                try
                {
                    ExpenseReport emp = db.ExpenseReport.Find(id);
                    db.ExpenseReport.Remove(emp);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }

            public Dictionary<string, decimal> CalculateMonthlyExpense()
            {
                ExpensesDataAcessLayer objexpense = new ExpensesDataAcessLayer();
                List<ExpenseReport> lstEmployee = new List<ExpenseReport>();
                Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();
                decimal foodSum = db.ExpenseReport.Where
                    (cat => cat.Category == "На Еду" && (cat.ExpenseDate > DateTime.Now.AddMonths(-1)))
                    .Select(cat => cat.Amount)
                    .Sum();
                decimal shoppingSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Переодические расходы" && (cat.ExpenseDate > DateTime.Now.AddMonths(-1)))
                   .Select(cat => cat.Amount)
                   .Sum();
                decimal travelSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Постоянные расходы" && (cat.ExpenseDate > DateTime.Now.AddMonths(-1)))
                   .Select(cat => cat.Amount)
                   .Sum();
                decimal healthSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Прочие расходы" && (cat.ExpenseDate > DateTime.Now.AddMonths(-1)))
                   .Select(cat => cat.Amount)
                   .Sum();
                dictMonthlySum.Add("На Еду", foodSum);
                dictMonthlySum.Add("Переодические расходы", shoppingSum);
                dictMonthlySum.Add("Постоянные расходы", travelSum);
                dictMonthlySum.Add("Прочие расходы", healthSum);
                return dictMonthlySum;
            }

            public Dictionary<string, decimal> CalculateWeeklyExpense()
            {
                ExpensesDataAcessLayer objexpense = new ExpensesDataAcessLayer();
                List<ExpenseReport> lstEmployee = new List<ExpenseReport>();
                Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();
                decimal foodSum = db.ExpenseReport.Where
                    (cat => cat.Category == "На Еду" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                    .Select(cat => cat.Amount)
                    .Sum();
                decimal shoppingSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Переодические расходы" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();
                decimal travelSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Постоянные расходы" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();
                decimal healthSum = db.ExpenseReport.Where
                   (cat => cat.Category == "Прочие расходы" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                   .Select(cat => cat.Amount)
                   .Sum();
                dictWeeklySum.Add("На Еду", foodSum);
                dictWeeklySum.Add("Переодические расходы", shoppingSum);
                dictWeeklySum.Add("Постоянные расходы", travelSum);
                dictWeeklySum.Add("Прочие расходы", healthSum);
                return dictWeeklySum;
            }

        }
    }