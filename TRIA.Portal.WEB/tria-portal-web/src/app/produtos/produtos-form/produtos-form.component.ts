import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { AlertModalService } from 'src/app/service/alert-modal.service';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-produtos-form',
  templateUrl: './produtos-form.component.html',
  styleUrls: ['./produtos-form.component.css']
})
export class ProdutosFormComponent implements OnInit {

  title: string= "Novo";
  id: number=0;
  produto: any ={
    id:0,
    nmProdutoServico:""
  }
  constructor(private _apiService: ApiService, private _alertService: AlertModalService, private router: Router
    ,private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get('id')!);
    this.title = this.id === 0 ? 'Novo' : 'Editar';

    if(this.id > 0){
      this._apiService.getApi("ProdutoServico/ConsultarPorId/".concat(this.id.toString())).subscribe(sucess => {
        if(sucess.isOk)
        this.produto = sucess.objetoRetorno
        else{
          console.error(sucess.mensagemRetorno);
          this._alertService.showError("Error ao Consultar, tente novamente!")
        }
      },error =>{
        console.error(error);
        this._alertService.showError("Error ao Consultar, tente novamente!")
      });
    }
}

  onSubmit(produtoForm: NgForm){
    this.produto={
      id: produtoForm.value.id,
      nmProdutoServico: produtoForm.value.nmProdutoServico
    }

    var req: Observable<any>= new Observable();
    if(this.produto.id > 0)
      req = this._apiService.postApi("ProdutoServico/Alterar",this.produto);
    else
      req = this._apiService.postApi("ProdutoServico/Inserir",this.produto);

      req.subscribe(sucess =>{
      if(sucess.isOk){
      this.router.navigate(["/produtos"])
      this._alertService.showSucess("Produto salvo com sucesso!")}
      else{
        console.error(sucess.mensagemRetorno);
        this._alertService.showError("Error ao salvar, tente novamente!")
      }
    },error =>{
      console.error(error);
      this._alertService.showError("Error ao salvar, tente novamente!")
    });

  }

}
