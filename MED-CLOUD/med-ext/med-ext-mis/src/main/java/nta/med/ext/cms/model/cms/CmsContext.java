package nta.med.ext.cms.model.cms;

public class CmsContext {

	private CmsSession cmsSession;

	public CmsContext(CmsSession cmsSession) {
		super();
		this.cmsSession = cmsSession;
	}

	private static InheritableThreadLocal<CmsContext> context = new InheritableThreadLocal<>();

	public static void init(CmsSession cmsSession) {
		context.set(new CmsContext(cmsSession));
	}

	public static CmsContext current() {
		return context == null ? null : context.get();
	}

	public CmsSession getCmsSession() {
		return cmsSession;
	}

	public void setCmsSession(CmsSession cmsSession) {
		this.cmsSession = cmsSession;
	}

}
