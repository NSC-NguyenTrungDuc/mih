package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00FbxBunCodeDataValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00FbxBunCodeDataValidatingResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310U00FbxBunCodeDataValidatingHandler extends ScreenHandler<BassServiceProto.BAS0310U00FbxBunCodeDataValidatingRequest, BassServiceProto.BAS0310U00FbxBunCodeDataValidatingResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0310U00FbxBunCodeDataValidatingHandler.class);
	
	@Resource                                                                                                       
	private Bas0230Repository bas0230Repository;
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;
	                                                                                                                
	@Override   
	@Transactional(readOnly = true)
	public BAS0310U00FbxBunCodeDataValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0310U00FbxBunCodeDataValidatingRequest request) throws Exception {
  	   	BassServiceProto.BAS0310U00FbxBunCodeDataValidatingResponse.Builder response = BassServiceProto.BAS0310U00FbxBunCodeDataValidatingResponse.newBuilder();                      
		String result = "";
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		switch (request.getColName()) {
			case "fbxBun_Code":
				result = bas0230Repository.getBunNameItemInfo(hospitalCode, language, request.getBunCode(),"",false);
				break;
			case "fbxDanui":
				List<String> listResult = ocs0132Repository.getOCS0132CodeNameList(hospitalCode, language, "ORD_DANUI", request.getCode(),false);
				if(!CollectionUtils.isEmpty(listResult)){
					result = listResult.get(0);
				}
				break;
			case "fbxMarume_Gubun":
				List<ComboListItemInfo> listCodeNameSortKey = bas0102Repository.getCodeNameSortKeyListItem(hospitalCode, language, "POGWAL_GUBUN", request.getCode());
				if(!CollectionUtils.isEmpty(listCodeNameSortKey)){
					result = listCodeNameSortKey.get(0).getCode();
				}
				break;
			default:
				break;
		}
		if(!StringUtils.isEmpty(result)){
			response.setFbxBunCode(result);
		}
		return response.build();
	}                                                                                                                 
}