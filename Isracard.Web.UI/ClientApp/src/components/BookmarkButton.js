import React, { Component } from 'react';
import { BookmarkApi } from "../data/BookmarkApi";
import { Glyphicon } from 'react-bootstrap';

export class BookmarkButton extends Component {
  displayName = BookmarkButton.name

  constructor(props) {
    super(props);
    this.state = { bookmarked: false };
  }

  handleBookmark(item, e) {

    if (!item) {
      return;
    }

    BookmarkApi.bookmarkItem(item)
      .then(data => {
        this.setState({ bookmarked: true });
      });
  }

  render() {
    if (!this.props.bookmarkEnabled) {
      return (<span></span>);
    }

    if (this.state.bookmarked) {
      return (<Glyphicon glyph='star' />);
    }

    return (
      <button onClick={(e) => this.handleBookmark(this.props.item, e)}>
        Bookmark
      </button>
    );
  }
}

BookmarkButton.defaultProps = {
  item: null,
  bookmarkEnabled: true
}
