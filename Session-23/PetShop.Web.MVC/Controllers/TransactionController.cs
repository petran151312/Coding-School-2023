﻿using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.MVC.Models.Pet;
using PetShop.Web.MVC.Models.Transaction;
using System.Data.Common;

namespace PetShop.Web.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;

        public TransactionController(IEntityRepo<Transaction> transactionRepo)
        {

            _transactionRepo = transactionRepo;
        }

        // GET: TransactionController
        public ActionResult Index()
        {
            var transactions = _transactionRepo.GetAll();
            return View(model: transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _transactionRepo.GetById(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }

            var viewtransaction = new TransactionDetailsDto
            {
                Id = id.Value,
                Date = transaction.Date,
                PetPrice = transaction.PetPrice,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice
            };

            return View(model: viewtransaction);
        }

        // GET: TransactionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateDto transaction)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var dbPetFood = new Transaction(transaction.PetPrice, transaction.PetFoodQty, transaction.PetFoodPrice, transaction.TotalPrice);
            _transactionRepo.Add(dbPetFood);
            return RedirectToAction("Index");
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id)
        {
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null)
            {
                return NotFound();
            }

            var viewtransaction = new TransactionEditDto();
            {
                viewtransaction.Date = dbTransaction.Date;
                viewtransaction.PetPrice = dbTransaction.PetPrice;
                viewtransaction.PetFoodQty = dbTransaction.PetFoodQty;
                viewtransaction.PetFoodPrice = dbTransaction.PetFoodPrice;
                viewtransaction.TotalPrice = dbTransaction.TotalPrice;
            };
            return View(model: viewtransaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEditDto transaction)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null)
            {
                return NotFound();
            }
#pragma warning disable CS8629 // Nullable value type may be null.
            dbTransaction.Date = (DateTime)transaction.Date;
#pragma warning restore CS8629 // Nullable value type may be null.
            dbTransaction.PetPrice = transaction.PetPrice;
            dbTransaction.PetFoodQty = transaction.PetFoodQty;
            dbTransaction.PetFoodPrice = transaction.PetFoodPrice;
            dbTransaction.TotalPrice = transaction.TotalPrice;
            _transactionRepo.Update(id, dbTransaction);
            return RedirectToAction(nameof(Index));

        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null)
            {
                return NotFound();
            }

            var viewtransaction = new TransactionDeleteDto
            {
                Date = dbTransaction.Date,
                PetPrice = dbTransaction.PetPrice,
                PetFoodQty = dbTransaction.PetFoodQty,
                PetFoodPrice = dbTransaction.PetFoodPrice,
                TotalPrice = dbTransaction.TotalPrice,
            };
            return View(model: viewtransaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _transactionRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
