import { AccountService } from './../../account/shared/account.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isAdministrador: boolean = false;
  nmUsuario: string = "";
  constructor(private router: Router, private _accountService: AccountService) { }

  ngOnInit(): void {
    this.nmUsuario = window.localStorage.getItem("usuario")!;
    this.isAdministrador = window.localStorage.getItem("perfil")!.toLowerCase() ==="administrador"?true: false;
  }
  onLogOut(): void{
    this._accountService.logOut();
    this.router.navigate(["/login"]);

  }

}
