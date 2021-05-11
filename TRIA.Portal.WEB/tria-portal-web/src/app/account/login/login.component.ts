import { Router } from '@angular/router';
import { AccountService } from './../shared/account.service';
import { Component, OnInit } from '@angular/core';
import { AlertModalService } from 'src/app/service/alert-modal.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login= {
    userName:'',
    password:''
  }
  constructor(private _accountService: AccountService, private router: Router, private _alertModal: AlertModalService) { }

  ngOnInit(): void {
  }

  async onSubmit(){
    try {
      const result =  await this._accountService.login(this.login);
      console.log(`Login Efetuado ${result}`);


      this.router.navigate(['']);

    } catch (error) {
      console.error(error);
      this._alertModal.showError("Error ao efetuar login, tente novamente!")
    }
  }

}
