import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EMPTY } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { AlertModalService } from 'src/app/service/alert-modal.service';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-produtos-list',
  templateUrl: './produtos-list.component.html',
  styleUrls: ['./produtos-list.component.css']
})
export class ProdutosListComponent implements OnInit {
produtos: any=[];
  constructor(private _apiService: ApiService, private _alertService: AlertModalService) { }

  ngOnInit() {
    this._apiService.getApi("ProdutoServico/ConsultarTodos").subscribe(
      (retorno)=>{
        if(retorno.isOk)
        this.produtos = retorno.objetoRetorno;
        else{
          console.error(retorno.mensagemRetorno);
          this._alertService.showError("Error ao consultar produtos, tente novamente!")
        }

      },
      (error) =>{console.error(error);
        this._alertService.showError("Error ao consultar produtos, tente novamente!")
      }
    )
  }

  onDelete(id:number){
    const result$ = this._alertService.showConfirm('Confirmação','Deseja excluir esse prouto/serviço?');

    result$.asObservable()
    .pipe(take(1),
      switchMap(result => result ? this._apiService.getApi("ProdutoServico/Deletar/".concat(id.toString())) : EMPTY)
    ).subscribe(success =>{
        if(success.isOk)
        this.ngOnInit();
        else{
          console.error(success.mensagemRetorno);
          this._alertService.showError("Error ao deletar, tente novamente!")
        }
      },error =>{
        console.error(error);
        this._alertService.showError("Error ao deletar, tente novamente!")
      }
    )
  }
  onEdit(id: number){

  }
}
