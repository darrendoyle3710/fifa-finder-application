import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor(private service: SharedService) { }

  PostList: any = [];

  @Input() per: any;
  Type: string;
  Platform: string;
  Position: string;
  PlayerRating: string;
  Description: string;


  ngOnInit(): void {
    this.refreshPostList();
  }

  refreshPostList() {
    this.service.getPostList().subscribe(data => {
      console.log(data);
      this.PostList = data;
    });
    console.log(this.PostList);
  }

  addPost() {
    var val = { Type: this.Type, Platform: this.Platform, Position: this.Position, PlayerRating: this.PlayerRating, Description: this.Description };

    this.service.addPost(val).subscribe(res => {
      alert(res.toString());
    });
  }

}
