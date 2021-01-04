import { Component, OnInit } from '@angular/core';
import { ProdutService } from '../../services/produt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produts',
  templateUrl: './produts.component.html',
  styleUrls: ['./produts.component.css']
})
export class ProdutsComponent implements OnInit {

  public produt: Produto[]

  constructor(private service: ProdutService, private router: Router) { }

  ngOnInit() {
    this.service.getAllProducts().subscribe(data => {
      this.produt = data;
    })
  }

  showProduto(id: number) {
    this.router.navigate(["/mostra-produto/" + id]);
  }

  deletaProduto(id: number) {
    this.router.navigate(["/deleta-produto/" + id]);
  }

}
