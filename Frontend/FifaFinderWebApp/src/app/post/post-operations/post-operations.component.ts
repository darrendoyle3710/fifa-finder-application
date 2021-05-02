import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { PostData } from 'src/app/post/post-data';

@Component({
  selector: 'app-post-operations',
  templateUrl: './post-operations.component.html',
  styleUrls: ['./post-operations.component.css']
})
export class PostOperationsComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() post: any;
  ID: number;
  Type: string;
  Platform: string;
  Position: string;
  PlayerRating: string;
  Description: string;

  postTypes: string[] = PostData.postTypes;
  platforms: string[] = PostData.platforms;
  positions: string[] = PostData.positions;
  playerRatings: string[] = PostData.playerRatings;

  ngOnInit(): void { }


  addPost() {
    var val = { ID: this.ID, Type: this.Type, Platform: this.Platform, Position: this.Position, PlayerRating: this.PlayerRating, Description: this.Description };

    this.service.addPost(val).subscribe(response => {
      alert(response.toString());
    });
  }

  editPost() {
    console.log(this.post.ID);
    var val = { ID: this.post.ID, Type: this.Type, Platform: this.Platform, Position: this.Position, PlayerRating: this.PlayerRating, Description: this.Description };
    this.service.updatePost(val).subscribe(response => {
      alert(response.toString());
    });
  }


}
