import React, { Component } from 'react';
import { BookmarkButton } from "./BookmarkButton";
import { BookmarkApi } from "../data/BookmarkApi";

export class SearchResult extends Component {
    displayName = SearchResult.name

    constructor(props) {
        super(props);
    }

    handleBookmark(item) {
        return BookmarkApi.bookmarkItem(item);
    }

    renderResult(items, bookmarkEnabled) {
        return (
            <div>
                <h2>Total: {items.length}</h2>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Avatar</th>
                            <th>Name</th>
                            <th>
                                &nbsp;
                        </th>
                        </tr>
                    </thead>
                    <tbody>
                        {items.map(item =>
                            <tr key={item.id}>
                                <td>
                                    <img className="img-thumbnail" src={item.owner.avatar_url} />
                                </td>
                                <td>{item.full_name}</td>
                                <td>
                                    <BookmarkButton item={item} bookmarkEnabled={bookmarkEnabled} />
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
    
    render() {
        let props = this.props;
        let bookMarkEnabled = props.bookMarkEnabled;

        let contents = props.items && props.items.length <= 0 ?
            <h3>No results</h3> :
            this.renderResult(props.items, bookMarkEnabled);

        return (
            <div>
                {contents}
            </div>
        );
    }
}

SearchResult.defaultProps = {
    items: [],
    bookMarkEnabled: true
}

