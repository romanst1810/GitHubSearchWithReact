import axios from 'axios';

export class BookmarkApi {
    displayName = BookmarkApi.name

    static bookmarkItem(item) {
        return axios.post('api/bookmark/' + item.id, item)
            .then(response => {
                item.bookmarked = true;
            });

    }

    static getItems() {
        return axios.get('api/bookmark')
            .then(response => response.data);
    }

}