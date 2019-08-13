function initAjaxForIndexField(formSelector, className) {
    $(formSelector).off('submit'); // prevent sending twice
    ajaxSubmitForIndexField($(formSelector), className);
}

function ajaxSubmitForIndexField(formObject, className) {

    formObject.one('submit', function (event) {

        event.preventDefault();

        var $form = $(this);
        $('.toast').hide();
        var isRequired = false;
        $('[required]').each(function () {
            if ($(this).val().length === 0) {
                isRequired = true;
                $(this).addClass("invalid");
            }
        });

        if (isRequired) {
            if (isRequired) {
                M.toast({ html: "Please fill in the required field(s)", classes: 'rounded red lighten-3' });
            }
            ajaxSubmitForIndexField($form, className);
            return false;
        }
        var invalid = $('.invalid').length;
        if (invalid > 0) {
            if (isRequired) {
                M.toast({ html: "Please fill in the required field(s)", classes: 'rounded red lighten-3' });
            }
            ajaxSubmitForIndexField($form, className);
            return false;
        }


        if (!$form.valid()) {
            ajaxSubmitForIndexField($form, className);
            return false;
        } else {
            var formData = new FormData();

            var collection = [];
            var datasetField = [];
            var files = [];
            $(className).each(function () {
                if ($(this).attr("name") !== undefined) {
                    var id = $(this).attr("id");
                    var name = $(this).attr("name");
                    var fieldType = $(this).attr("fieldType");
                    var value = $(this).val();
                    var submoduleid = $(this).attr("submoduleid");
                    var fields = {};
                    if (fieldType === "Attachment") {
                        if ($("#" + id)[0].files !== null) {
                            var file = $("#" + id)[0].files[0];
                            if (file !== null) {
                                formData.append('file', file);
                                fields = { "fieldid": id, "type": fieldType, "value": value, "submoduleid": submoduleid, file: true };
                            } else {
                                fields = { "fieldid": id, "type": fieldType, "value": value, "submoduleid": submoduleid, file: false };
                            }
                        } else {
                            fields = { "fieldid": id, "type": fieldType, "value": value, "submoduleid": submoduleid, file: false };
                        }

                    } else {
                        fields = { "fieldid": id, "type": fieldType, "value": value, "submoduleid": submoduleid, file: false };
                    }

                    collection.push(fields);
                }
            });

            $(".dataset").each(function () {
                if ($(this).attr("name") !== undefined) {
                    var id = $(this).attr("id");
                    var name = $(this).attr("name");
                    var fieldType = $(this).attr("fieldType");
                    var value = $(this).val();
                    var datasetid = $(this).attr("datasetid");
                    var datasetFields = {};
                    if (fieldType === "Attachment") {
                        if ($("#" + id)[0].files !== null) {

                            var file = $("#" + id)[0].files[0];
                            if (file !== null) {
                                formData.append('datasetfile', file);
                                datasetFields = { "fieldid": id, "type": fieldType, "value": value, "datasetid": datasetid, file: true };
                            } else {
                                datasetFields = { "fieldid": id, "type": fieldType, "value": value, "datasetid": datasetid, file: false };
                            }
                        } else {
                            datasetFields = { "fieldid": id, "type": fieldType, "value": value, "datasetid": datasetid, file: false };
                        }

                    } else {
                        datasetFields = { "fieldid": id, "type": fieldType, "value": value, "datasetid": datasetid, file: false };
                    }

                    datasetField.push(datasetFields);
                }
            });

            var url = $form.attr("form-submit-url");
            var id = $("#docId").val();

            formData.append('id', id);
            formData.append('submoduleid', $("#docSubModuleId").val());
            formData.append('jsondocumentfield', JSON.stringify(collection));
            formData.append('status', $("#docStatus").val());
            formData.append('datanumber', $("#docDataNumber").val());
            formData.append('jsondatasetfield', JSON.stringify(datasetField));
            formData.append('datasetid', $("#docDatasetId").val());
            formData.append('buttonaction', $("#buttonAction").val());

            Pace.track(function () {
                $.ajax({
                    type: 'POST',
                    url: url,
                    cache: false,
                    contentType: false,
                    processData: false,
                    data: formData,
                    success: function (data, status) {
                        $('.toast').hide();
                        if (data.success) {
                            M.toast({ html: data.message, classes: 'rounded blue lighten-3' });
                            if (id === "0") {
                                location.href = $form.attr("form-next-url") + "/" + data.id;
                            } else {
                                location.href = $form.attr("form-next-url");
                            }
                        } else {
                            M.toast({ html: data.message, classes: 'rounded red lighten-3' });
                            ajaxSubmitForIndexField($form, className);
                        }
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                });
            });
        }
    });
}

function initAjaxField(formSelector) {
    $(formSelector).off('submit'); // prevent sending twice
    ajaxSubmitField($(formSelector))
}

function ajaxSubmitField(formObject) {

    formObject.one('submit', function (event) {

        event.preventDefault();

        var $form = $(this);
        $('.toast').hide();
        var isValid = false;
        var id = $form.attr("id");

        $('#' + id + ' .required').each(function () {
            var fieldType = $(this).attr("type");

            if ("text" !== fieldType) {
                var optionValue = $(this).find(":selected").val();
                var dataTarget = $(this).prevAll("input[type=text]").attr("data-target");
                if (optionValue === "Choose your option" || optionValue === undefined) {
                    $('input[data-target=' + dataTarget + ']').addClass("invalid");
                    isRequired = true;
                } else {
                    $('input[data-target=' + dataTarget + ']').removeClass("invalid").addClass("valid");
                }
            } else {
                if ($(this).val().length === 0) {
                    isValid = false;
                    $(this).addClass("invalid");
                } else {
                    isValid = true;
                    $(this).addClass("valid");
                }
            }
        });

        if (!isValid) {
            ajaxSubmitField($form);
            return false;
        } else {
            var formData = new FormData();
            Pace.track(function () {
                $.ajax({
                    type: $form.attr('method'),
                    url: $form.attr('action'),
                    data: $form.serialize(),
                    success: function (data, status) {
                        $('.toast').hide();
                        if (data.success) {
                            M.toast({ html: data.message, classes: 'rounded blue lighten-3' });
                            $('.modal').modal('close');
                            if (data.message === "Field has been successfully added.") {
                                location.reload();
                            } else {
                                ajaxSubmitField($form);
                            }
                        } else {
                            M.toast({ html: data.message, classes: 'rounded red lighten-3' });
                            ajaxSubmitField($form);
                        }
                    },
                    error: function (xhr, status, error) {
                        ajaxSubmitField($form);
                    }
                });
            });
        }
    });
}

function initAjaxForm(formSelector) {
    $(formSelector).off('submit'); // prevent sending twice
    ajaxSubmitForm($(formSelector));
}

function ajaxSubmitForm(formObject) {
    formObject.one('submit', function (event) {
        event.preventDefault();

        var $form = $(this);
        $('.toast').hide();
        $form.validate({
            errorPlacement: function (error, element) {

            }
        });
        if (!$form.valid()) {
            var isRequired = false;
            $("label[class='error']").hide();
            $('[required]').each(function () {
                var fieldType = $(this).attr("type");
                if ("text" !== fieldType && "password" !== fieldType && "email" !== fieldType) {
                    var optionValue = $(this).find(":selected").val();
                    var dataTarget = $(this).prevAll("input[type=text]").attr("data-target");

                    if (optionValue === "Choose your option") {
                        $('input[data-target=' + dataTarget + ']').addClass("invalid");
                        isRequired = true;
                    } else {
                        $('input[data-target=' + dataTarget + ']').removeClass("invalid").addClass("valid");
                    }
                } else {
                    if ($(this).val() !== null) {
                        if ($(this).val().length === 0) {
                            isRequired = true;
                            $(this).addClass("invalid");
                        }
                    }
                }
            });
            if (isRequired) {
                M.toast({ html: "Please fill in the required field(s)", classes: 'rounded red lighten-3' });
            }
            ajaxSubmitForm($form);
            return false;
        } else {
            var formData = new FormData();
            Pace.track(function () {
                $.ajax({
                    type: $form.attr('method'),
                    url: $form.attr('action'),
                    data: $form.serialize(),
                    success: function (data, status) {
                        //if the submit is success
                        if (data.success) {
                            M.toast({ html: data.message, classes: 'rounded blue lighten-3' });

                            //if the page should redirect after submit
                            if (data.isRedirect) {
                                window.location.href = '/' + data.redirectUrl;
                            }

                            else {
                                location.reload();
                            }
                        } else {

                            //if the submit is error from backend, adjust classes of fields
                            $('[required]').each(function () {
                                var fieldType = $(this).attr("type");
                                if ("text" !== fieldType && "password" !== fieldType && "email" !== fieldType) {
                                    var optionValue = $(this).find(":selected").val();
                                    var dataTarget = $(this).prevAll("input[type=text]").attr("data-target");

                                    if (optionValue === "Choose your option") {
                                        $('input[data-target=' + dataTarget + ']').addClass("invalid");
                                        isRequired = true;
                                    } else {
                                        $('input[data-target=' + dataTarget + ']').removeClass("invalid").addClass("valid");
                                    }
                                } else {
                                    if ($(this).val() !== null) {
                                        if ($(this).val().length === 0) {
                                            isRequired = true;
                                            $(this).addClass("invalid");
                                        }
                                    }
                                }

                            });
                            M.toast({ html: data.message, classes: 'rounded red lighten-3' });
                            ajaxSubmitForm($form);
                        }
                    },
                    error: function (xhr, status, error) {
                        ajaxSubmitForm($form);
                    }
                });
            });
        }
    });
}

$("select").on('change', function () {
    if ($(this).val() !== "Choose your option") {
        var optionValue = $(this).find(":selected").val();
        var dataTarget = $(this).prevAll("input[type=text]").attr("data-target");
        $('input[data-target=' + dataTarget + ']').removeClass("invalid").addClass("valid");
    }
    else {
    }
});

//note: added by haime, need checking
//about: adding active class in sub modules
//error: error in before solution was the validation is invalid. 
//ex: /Maintenance/LifeCycleField and sub module "Field" is consider as active instead of "LifeCycleField"
$(document).ready(function () {
    activeSubModules();
});

//new code for adding "active" class in active sub modules
function activeSubModules() {
    var hasMatch = false;

    //get url ex: "/Maintenance/Field"
    var url = window.location.pathname.split("/");

    //change url to only /Controller/Action
    url = "/" + url[1] + "/" + url[2];

    //add "active" class to a(link) with href of the url
    $('a[href$="' + String(url) + '"]').addClass("active");

    //if a(link) exist
    if ($('a[href$="' + String(url) + '"]').length > 0) {
        //if url is from button and not from tabs
        hasMatch = true;

        //set a local value to be passed on the next page, this value will be use if the url is not from tabs
        localStorage.setItem("previousSubModule", String(url));
    }

    //if url is not from tabs(module, subModule)
    if (hasMatch == false) {
        //add a active class to previous sub module that was active
        $('a[href$="' + String(localStorage.getItem("previousSubModule")) + '"]').addClass("active");
    }
}
