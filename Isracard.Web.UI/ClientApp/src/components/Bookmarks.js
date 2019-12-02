import React, { Component } from 'react';
import {SearchResult} from "./SearchResult";
import {BookmarkApi} from "../data/BookmarkApi";

export class Bookmarks extends Component {
  displayName = Bookmarks.name

  constructor(props) {
      super(props);
      this.state = {items: [], loading: true};

      BookmarkApi.getItems()
          .then(data => {
              this.setState({loading: false});
              this.setState({items: data});
          });
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : <SearchResult items={this.state.items} bookMarkEnabled={false}/>;

    return (
      <div>
        <h1>Bookmarks</h1>
        {contents}
      </div>
    );
  }
}
