define([
  'jquery',
  'underscore',
  'backbone',
  'text!templates/skills.html'
], function ($, _, Backbone, skillsTemplate) {
  var SkillView = Backbone.View.extend({

    //... is a list tag.
    tagName: "tr",

    // Cache the template function for a single item.
    template: _.template(skillsTemplate),

    // The DOM events specific to an item.
    events: {
    },

    // The TodoView listens for changes to its model, re-rendering. Since there's
    // a one-to-one correspondence between a **Todo** and a **TodoView** in this
    // app, we set a direct reference on the model for convenience.
    initialize: function () {
      this.model.bind('change', this.render);
      this.model.bind('destroy', this.remove);
    },

    // Re-render the contents of the todo item.
    render: function () {
      $(this.el).html(this.template(this.model.toJSON()));
      return this;
    }
  });

  return SkillView;
});