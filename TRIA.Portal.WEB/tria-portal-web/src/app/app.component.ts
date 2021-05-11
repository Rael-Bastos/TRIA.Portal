import { Component } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { AlertModalService } from './service/alert-modal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'tria-portal-web';
constructor(private _alertService: AlertModalService){}
  onDelete(){
    const result$ = this._alertService.showConfirm('Confirmação','Deseja excluir esse prouto/serviço?');

    result$.asObservable()
    .pipe(
      take(1),
      switchMap(result => result ? this.deletar(1) : EMPTY)
    ).subscribe(
      success =>{

      },
      error =>{

      }
    )
  }

  deletar(id: number): Observable<any>{
    alert("aqui")

    return new Observable;
  }

  onTeste(){
     this._alertService.showSucess('Error ao Testar');
    }
}
