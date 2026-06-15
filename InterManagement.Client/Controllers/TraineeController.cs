using InterManagement.Application.Features.Trainees.DTOs;
using InterManagement.Client.Services;
using InterManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterManagement.Client.Controllers;

public class TraineeController : BaseController
{
    private readonly ITraineeApiService _traineeService;

    public TraineeController(ITraineeApiService traineeService)
    {
        _traineeService = traineeService;
    }

    public async Task<IActionResult> Index(TraineeStatus? status = null)
    {
        var trainees = status.HasValue
            ? await _traineeService.GetByStatusAsync(status.Value)
            : await _traineeService.GetAllAsync();

        ViewBag.CurrentStatus = status;
        return View(trainees);
    }

    public async Task<IActionResult> Details(int id)
    {
        var trainee = await _traineeService.GetDetailsAsync(id);
        if (trainee is null) return NotFound();
        return View(trainee);
    }

    public IActionResult Create() => View(new CreateTraineeDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTraineeDto model)
    {
        var created = await _traineeService.CreateAsync(model);
        if (created is null)
        {
            SetError("Failed to create trainee. The email may already be in use or the dates are invalid.");
            return View(model);
        }

        SetSuccess($"Trainee {created.FirstName} {created.LastName} created successfully.");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var trainee = await _traineeService.GetByIdAsync(id);
        if (trainee is null) return NotFound();

        var dto = new UpdateTraineeDto
        {
            FirstName = trainee.FirstName,
            LastName = trainee.LastName,
            Email = trainee.Email,
            University = trainee.University,
            Specialty = trainee.Specialty,
            Theme = trainee.Theme,
            StartDate = trainee.StartDate,
            EndDate = trainee.EndDate,
            Status = trainee.Status
        };

        ViewBag.TraineeId = id;
        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateTraineeDto model)
    {
        var updated = await _traineeService.UpdateAsync(id, model);
        if (updated is null)
        {
            SetError("Failed to update trainee. Please verify the data and try again.");
            ViewBag.TraineeId = id;
            return View(model);
        }

        SetSuccess($"Trainee {updated.FirstName} {updated.LastName} updated successfully.");
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var trainee = await _traineeService.GetByIdAsync(id);
        if (trainee is null) return NotFound();
        return View(trainee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var success = await _traineeService.DeleteAsync(id);
        if (!success)
        {
            SetError("Failed to delete trainee.");
            return RedirectToAction(nameof(Delete), new { id });
        }

        SetSuccess("Trainee deleted successfully.");
        return RedirectToAction(nameof(Index));
    }
}
