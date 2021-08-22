import axios from 'axios';

const baseUrl = `http://localhost`

const get = (url) => axios.get(url)
const post = (url, data) => axios.post(url, data)
const put = (url, data) => axios.put(url, data)
const remove = (url) => axios.delete(url)

export const commonService = {
  get,
  post,
  put,
  remove
}