package nta.med.service.ihis.handler.bass;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadComboDataSourceRequest;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadComboDataSourceResponse;
import nta.med.service.ihis.proto.CommonModelProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComBizLoadComboDataSourceHandler extends ScreenHandler<BassServiceProto.ComBizLoadComboDataSourceRequest, BassServiceProto.ComBizLoadComboDataSourceResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ComBizLoadComboDataSourceHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;   
	@Resource
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public ComBizLoadComboDataSourceResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ComBizLoadComboDataSourceRequest request) throws Exception {
  	   	BassServiceProto.ComBizLoadComboDataSourceResponse.Builder response = BassServiceProto.ComBizLoadComboDataSourceResponse.newBuilder();                      
		List<ComboListItemInfo> list = new ArrayList<ComboListItemInfo>();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		switch (request.getColName()) {
		case "gwa":
			list = bas0260Repository.getComboListFromVwBasGwa(hospitalCode, language, request.getArgu1());
			break;
		case "doctor":
			list = bas0270Repository.getOcsOrderBizLoadComboDataSourceListItem(hospitalCode, request.getArgu2(), request.getArgu1());
			break;
		case "doctor_all":
			list.add(new ComboListItemInfo("%", "全体"));
			list.addAll(bas0270Repository.getOcsOrderBizLoadComboDataSourceListItem(hospitalCode, request.getArgu2(), request.getArgu1()));
			break;

		default:
			break;
		}
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}                                                                                                            
}