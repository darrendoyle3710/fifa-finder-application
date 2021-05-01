import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

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
  PlayerRating: number;
  Description: string;

  postTypes: string[] = ['Looking For Club', 'Looking For Player'];
  platforms: string[] = ['PS5', 'Xbox Series X', 'PC', 'Xbox One', 'PS4'];
  positions: string[] = ['GK', 'RB', 'LB', 'CB', 'CDM', 'CM', 'CAM', 'LM', 'RM', 'RW', 'LW', 'RF', 'LF', 'ST'];
  playerRatings: number[] = [80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92];

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
