package nta.med.data.dao.medi.drg;

/**
 * @author dainguyen.
 */
public interface Drg9043RepositoryCustom {
	
	public String checkDrgsDRG5100P01GetTimer(String currentTime, String hospCode);
	
	public String getOCS6010U10PopupIfJusaConf(String hospCode);
}

