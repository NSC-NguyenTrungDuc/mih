/**
 * 
 */
package nta.sfd.misc.navigation;

import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import nta.sfd.misc.navigation.NavigationConfig.NavigationType;

/**
 * The Class Navigation.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
public class Navigation {
	private Map<NavigationType, List<NavigationItem>> navigationsList;

	/**
	 * Gets the navigations list.
	 * 
	 * @return the navigations list
	 */
	public Map<NavigationType, List<NavigationItem>> getNavigationsList() {
		return navigationsList != null ? navigationsList : new LinkedHashMap<NavigationConfig.NavigationType, List<NavigationItem>>();
	}

	/**
	 * Sets the navigations list.
	 * 
	 * @param navigationsList
	 *            the navigations list
	 */
	public void setNavigationsList(
			Map<NavigationType, List<NavigationItem>> navigationsList) {
		this.navigationsList = navigationsList;
	}
}
