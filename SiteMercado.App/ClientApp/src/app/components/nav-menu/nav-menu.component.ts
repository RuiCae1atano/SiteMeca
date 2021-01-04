import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  isLogged;

  constructor(private auth: AuthService) {} 

  ngOnInit() {

    //necessario checkar se o cara esta logado
    //this.auth.logged = false;
    this.isLogged = this.auth.checkLogged();
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
