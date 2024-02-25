using Microsoft.AspNetCore.Components;
using TaskEvidence.Client.Pages;
using TaskEvidence.Models;

namespace TaskEvidence.Pages.ServiceDesk
{
    public class WorkflowItemBase : ComponentBase
    {
        [Parameter]
        public EventCallback<ChecklistModel> OnChecklistModelChanged { get; set; }
        [Parameter]
        public ChecklistModel ChecklistModel { get; set; }

        [Parameter]
        public string BtnDescription { get; set; }
        [Parameter]
        public bool IsReadOnly { get; set; } = false;
        [Parameter]
        public EventCallback<bool> OnToggleDescription { get; set; }

        [Parameter]
        public EventCallback<bool> OnStatusChanged { get; set; }
        [Parameter]
        public bool IsStatusVisible { get; set; } = false;
        protected override void OnParametersSet()
        {
            if (ChecklistModel != null)
            {
                BtnDescription = ChecklistModel.ShowDescription ? "Skrýt" : "Popis";

                //ChecklistModel.Deadline = ChecklistModel.Deadline ?? DateTime.Today.AddDays(1).AddSeconds(-1);
                //ChecklistModel.Deadline ??= DateTime.Today.AddDays(1).AddSeconds(-1);
                //ChecklistModel.Deadline = ChecklistModel.Deadline != null ? ((DateTime)ChecklistModel.Deadline).Date.AddDays(1).AddSeconds(-1) : DateTime.Today.AddDays(1).AddSeconds(-1);
            }
        }
        protected async Task ToggleDescription()
        {
            ChecklistModel.ShowDescription = !ChecklistModel.ShowDescription;

            BtnDescription = ChecklistModel.ShowDescription ? "Skrýt" : "Popis";

            StateHasChanged();
            await OnToggleDescription.InvokeAsync(ChecklistModel.ShowDescription);
        }
    }
}
