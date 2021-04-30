import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor(private service: SharedService) { }

  postTypes: string[] = ['Looking For Club', 'Looking For Player'];
  platforms: string[] = ['PS5', 'Xbox Series', 'PC', 'Xbox One', 'PS4'];
  positions: string[] = ['GK', 'RB', 'LB', 'CB', 'CDM', 'CM', 'CAM', 'LM', 'RM', 'RW', 'LW', 'RF', 'LF', 'ST'];
  playerRatings: number[] = [80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92];


  @Input() post: any;
  Id: number;
  Type: string;
  Platform: string;
  Position: string;
  PlayerRating: number;
  Description: string;

  PostList: any = [];

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

    this.service.addPost(val).subscribe(response => {
      alert(response.toString());
    });
  }




}
