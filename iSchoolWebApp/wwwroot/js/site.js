// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery(document).ready(function () {
    //Accordion for Undergraduate section
    jQuery("#accordion-under").accordion({
        heightStyle: "content",
        animate: true,
        collapsible: true
    });
    //Accordion for Graduate section
    jQuery("#accordion-grad").accordion({
        heightStyle: "content",
        animate: true,
        collapsible: true
    });
    //Accordion for Minors page
    jQuery("#accordion-minor").accordion({
        heightStyle: "content",
        animate: true,
        collapsible: true
    });
    //add Tables for Employment and Co-op
    jQuery("#emptTable").DataTable();
    jQuery("#co-op").DataTable();

    //Tried to add tabs but with the way Courses in api/course was set up,
    //I was unable to receive the course's description if
    //course's title is identical to course's courseID
    // therefore I receive the course's description
    //jQuery(".tabs").tabs();
});

