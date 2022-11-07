using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeveloperRoadMap.Models;
using DeveloperRoadMap.Models.Extensions;

namespace DeveloperRoadMap.ViewModels
{
    [ObservableObject]
    public partial class StepsListViewModel
    {
        public StepsListViewModel()
        {
            steps.Push(new Step("Become C# Developer"));
            steps.Push(new Step("Learn Classes"));
            steps.Push(new Step("Learn Functions"));
            steps.Push(new Step("Learn For loops"));
            steps.Push(new Step("Learn if else"));
            steps.Push(new Step("Learn variables"));
            StepCount = Steps.Count;
        }
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(StepCompleteCommand))]
        private ObservableStack<Step> steps = new ();

        [ObservableProperty]
        private int stepCount;

        [RelayCommand]
        private async Task StepComplete()
        {
            if (steps.Any())
            {
                Steps.Pop();
                StepCount = Steps.Count;
                await Task.CompletedTask;
            }
        }
        
    }
}

