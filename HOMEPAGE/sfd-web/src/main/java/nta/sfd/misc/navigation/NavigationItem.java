/**
 * 
 */
package nta.sfd.misc.navigation;

import java.util.List;

import nta.sfd.misc.navigation.NavigationConfig.NavigationGroup;

/**
 * The Class NavigationItem.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
public class NavigationItem {
	private String label;
	private String link;
	private String iconClass;
	private boolean active;
	private NavigationGroup group;
	private NavigationItem parent;
	private List<NavigationItem> children;
	
	/**
	 * Instantiates a new navigation item.
	 */
	public NavigationItem() {
		
	}
	
	/**
	 * Instantiates a new navigation item.
	 * 
	 * @param item
	 *            the item
	 */
	public NavigationItem(NavigationItem item) {
		this.label = item.label;
		this.link = item.link;
		this.group = item.group;
		this.parent = item.parent;
		this.active = item.active;
		this.children = item.children;
		this.iconClass = item.iconClass;
	}
	
	/**
	 * Gets the label.
	 * 
	 * @return the label
	 */
	public String getLabel() {
		return label;
	}
	
	/**
	 * Sets the label.
	 * 
	 * @param label
	 *            the new label
	 */
	public void setLabel(String label) {
		this.label = label;
	}
	
	/**
	 * Gets the link.
	 * 
	 * @return the link
	 */
	public String getLink() {
		return link;
	}
	
	/**
	 * Sets the link.
	 * 
	 * @param link
	 *            the new link
	 */
	public void setLink(String link) {
		this.link = link;
	}

	public String getIconClass() {
		return iconClass;
	}

	public void setIconClass(String iconClass) {
		this.iconClass = iconClass;
	}

	/**
	 * Checks if is active.
	 * 
	 * @return true, if is active
	 */
	public boolean isActive() {
		return active;
	}
	
	/**
	 * Sets the active.
	 * 
	 * @param active
	 *            the new active
	 */
	public void setActive(boolean active) {
		this.active = active;
	}
	
	/**
	 * Gets the group.
	 * 
	 * @return the group
	 */
	public NavigationGroup getGroup() {
		return group;
	}
	
	/**
	 * Sets the group.
	 * 
	 * @param group
	 *            the new group
	 */
	public void setGroup(NavigationGroup group) {
		this.group = group;
	}
	
	/**
	 * Gets the parent.
	 * 
	 * @return the parent
	 */
	public NavigationItem getParent() {
		return parent;
	}

	/**
	 * Sets the parent.
	 * 
	 * @param parent
	 *            the new parent
	 */
	public void setParent(NavigationItem parent) {
		this.parent = parent;
	}

	/**
	 * Gets the children.
	 * 
	 * @return the children
	 */
	public List<NavigationItem> getChildren() {
		return children;
	}

	/**
	 * Sets the children.
	 * 
	 * @param children
	 *            the new children
	 */
	public void setChildren(List<NavigationItem> children) {
		this.children = children;
	}
}
