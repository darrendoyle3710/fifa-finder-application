import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-post-display',
  templateUrl: './post-display.component.html',
  styleUrls: ['./post-display.component.css']
})
export class PostDisplayComponent implements OnInit {

  constructor(private service: SharedService) { }

  PostList: any = [];

  PostTypeFilter: string = "";
  PostPlatformFilter: string = "";
  PostPositionFilter: string = "";
  PostListUnfiltered: any = [];

  ModalTitle: string;
  ShowPostOperations: boolean = false;
  post: any;

  ngOnInit(): void {
    this.refreshPostList();
  }

  refreshPostList() {
    this.service.getPostList().subscribe(data => {
      this.PostList = data;
      this.PostListUnfiltered = data;
    });
  }

  addClick() {
    this.post = {
      ID: 0,
      Type: "",
      Platform: "",
      Position: "",
      PlayerRating: 80,
      Description: "",
    }
    this.ModalTitle = "Add Post";
    this.ShowPostOperations = true;
  }
  closeClick() {
    this.ShowPostOperations = false;
    this.refreshPostList();
  }

  editPostClick(item) {
    console.log(item);
    this.post = item;
    this.post
    this.ModalTitle = "Edit Post";
    this.ShowPostOperations = true;
  }

  deletePostClick(item) {
    if (confirm('Are you sure you want to delete this post? This action is irreversible.')) {
      console.log(item.ID);
      this.service.deletePost(item.ID).subscribe(data => {
        alert(data.toString());
        this.refreshPostList();
      })
    }
  }

  FilterFn() {
    var PostTypeFilter = this.PostTypeFilter;

    this.PostList = this.PostListUnfiltered.filter(function (el) {
      return el.Type.toString().toLowerCase().includes(
        PostTypeFilter.toString().trim().toLowerCase()
      )
    });
  }

}
