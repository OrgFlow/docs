/**
 * This method will be called at the start of exports.transform in conceptual.html.primary.js
 */
exports.preTransform = function (model) {
	return model;
}

/**
 * This method will be called at the end of exports.transform in conceptual.html.primary.js
 */
exports.postTransform = function (model) {
	for (var i = 0; i < model._toc.items.length; i++) {
		var item = model._toc.items[i];

		item.isTopLevel = true;
		item.firstChildHref = getFirstChildHref(item);

		traverseItems(model.uid, item);
	}

	return model;
}

function traverseItems(uid, item) {
	var isActive = uid && item.topicUid === uid;

	item.hasChildren = item.items.length > 0;

	for (var i = 0; i < item.items.length; i++) {
		isActive = traverseItems(uid, item.items[i]) || isActive;
	}

	item.active = isActive;

	return isActive;
}

function getFirstChildHref(item) {
	if (item.href) {
		return item.href;
	}

	for (var i = 0; i < item.items.length; i++) {
		var href = getFirstChildHref(item.items[i]);

		if (href) {
			return href;
		}
	}

	return null;
}