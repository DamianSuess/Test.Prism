﻿using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Test.PrismXF.ViewModels
{
  public class CustomMDViewModel : BindableBase
  {
    private INavigationService _navigationService;


    public CustomMDViewModel(INavigationService navService)
    {
      _navigationService = navService;
    }

    public DelegateCommand<string> NavigateCommand => new DelegateCommand<string>(NavigateAsync);

    private async void NavigateAsync(string page)
    {
      await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
    }
  }
}