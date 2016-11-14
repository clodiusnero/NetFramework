<%@ Page Title="Ganic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="store._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">

  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="Images/Slider/slider1.jpg" alt="..."/>
      <div class="carousel-caption">
        ...
      </div>
    </div>
    <div class="item">
        <img src="Images/Slider/slider2.jpg" alt="..."/>
      <div class="carousel-caption">
        ...
      </div>
    </div>
          <div class="item">
        <img src="Images/Slider/slider3.jpg" alt="..."/>
      <div class="carousel-caption">
        ...
      </div>
    </div>
    ...
  </div>

  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
    <div class="container">
            <img src="images/Kids-Ready.jpg" alt="kids" />
    </div>
</asp:Content>
