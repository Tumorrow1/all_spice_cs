import { DatabaseItem } from "./Databaseitems.js"

export class Recipe extends DatabaseItem {
  constructor(data) {
    super(data)
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.creator_id = data.creator_id
  }
}