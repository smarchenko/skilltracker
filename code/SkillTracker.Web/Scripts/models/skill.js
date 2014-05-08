define(['underscore', 'backbone'], function (_, Backbone) {
  var SkillModel = Backbone.Model.extend({

    // Default attributes for the category.
    defaults: {
      description: "no description available...",
      name: "no name available...",
    },

    // Ensure that each category created has `content`.
    initialize: function () {
      if (!this.get("description")) {
        this.set({ "description": this.defaults.description });
      }
      
      if (!this.get("name")) {
        this.set({ "name": this.defaults.name });
      }
    }
  });
  
  return SkillModel;
});
