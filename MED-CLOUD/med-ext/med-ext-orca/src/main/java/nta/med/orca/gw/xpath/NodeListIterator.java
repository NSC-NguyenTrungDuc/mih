// This is free software released into the public domain (CC0 license).

package nta.med.orca.gw.xpath;

import org.w3c.dom.DOMException;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.traversal.NodeFilter;
import org.w3c.dom.traversal.NodeIterator;

/**
 * A simple iterator over a NodeList
 */
class NodeListIterator implements NodeIterator {
	private final int INVALID = -2;

	private int position;
	private NodeList list;
	private int length;

	protected NodeListIterator(final NodeList list) {
		this.list = list;
		length = list.getLength();
		position = 0;
	}

	public void detach() {
		position = INVALID;
		list = null;
		length = 0;
	}

	public boolean getExpandEntityReferences() {
		// XXX: correct?
		return true;
	}

	public NodeFilter getFilter() {
		// XXX: correct?
		return null;
	}

	public Node getRoot() {
		// XXX: correct?
		return list.item(0);
	}

	public int getWhatToShow() {
		// XXX: correct?
		return NodeFilter.SHOW_ALL;
	}

	public Node nextNode() throws DOMException {
		checkValidState("next");

		if (position >= length) {
			return null;
		}

		Node node = list.item(position);
		position = position + 1;
		return node;
	}

	public Node previousNode() throws DOMException {
		checkValidState("previous");

		if (position == 0) {
			return null;
		}

		position = position - 1;
		Node node = list.item(position);
		return node;
	}

	private void checkValidState(String direction) throws DOMException {
		if (position == INVALID) {
			// FIXME: use the default message string
			String msg = "Called " + direction + "Node() after detach()";
			throw new DOMException(DOMException.INVALID_STATE_ERR, msg);
		}
	}
}
