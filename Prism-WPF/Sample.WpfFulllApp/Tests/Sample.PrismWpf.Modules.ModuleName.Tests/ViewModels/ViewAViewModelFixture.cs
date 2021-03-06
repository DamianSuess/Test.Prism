﻿using Moq;
using Prism.Regions;
using Test.PrismWpf.Modules.ModuleName.ViewModels;
using Test.PrismWpf.Services.Interfaces;
using Xunit;

namespace Test.PrismWpf.Modules.ModuleName.Tests.ViewModels
{
  public class ViewAViewModelFixture
  {
    const string MessageServiceDefaultMessage = "Some Value";
    Mock<IMessageService> _messageServiceMock;
    Mock<IRegionManager> _regionManagerMock;
    public ViewAViewModelFixture()
    {
      var messageService = new Mock<IMessageService>();
      messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
      _messageServiceMock = messageService;

      _regionManagerMock = new Mock<IRegionManager>();
    }

    [Fact]
    public void MessageINotifyPropertyChangedCalled()
    {
      var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);
      Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
    }

    [Fact]
    public void MessagePropertyValueUpdated()
    {
      var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

      _messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

      Assert.Equal(MessageServiceDefaultMessage, vm.Message);
    }
  }
}
