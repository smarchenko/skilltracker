define(['underscore', 'backbone'], function (_, Backbone) {
  var SkillModel = Backbone.Model.extend({

    // Default attributes for the category.
    defaults: {
      text: "no text available...",
    },

    // Ensure that each category created has `content`.
    initialize: function () {
      if (!this.get("text")) {
        this.set({ "text": this.defaults.text });
      }
    }
  });
  
  return SkillModel;
});
