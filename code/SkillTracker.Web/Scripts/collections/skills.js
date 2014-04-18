define([
  'underscore',
  'backbone',
  'models/category'
], function (_, Backbone, Skill) {

  var SkillsCollection = Backbone.Collection.extend({

    // Reference to this collection's model.
    model: Skill,

    url: function () {
      return "api/Skills" + (this.get('id') ? '?skillid=' + this.get('id') : '');
    }
  });
  
  return new SkillsCollection;
});
