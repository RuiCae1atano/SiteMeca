import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutService } from 'src/app/services/produt.service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {
  public produto: Produto;
  imagem;

  constructor(private service: ProdutService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.service.showProducts(this.route.snapshot.params.id).subscribe(data => {
      this.produto = data;
      this.imagem = data.imagem;
    })      
  }


  deleteProduto(id: number){
      this.service.deletaProduto(id).subscribe(data =>{
        this.router.navigate(["/produtos"]);
      })
  }
}
