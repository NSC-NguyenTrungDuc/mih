package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsOrderBizLoadComboDataSourceHandler extends ScreenHandler<NuroServiceProto.OcsOrderBizLoadComboDataSourceRequest, NuroServiceProto.OcsOrderBizLoadComboDataSourceResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsOrderBizLoadComboDataSourceHandler.class);                                        
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;      
	@Resource
	private Ocs0132Repository ocs0132Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OcsOrderBizLoadComboDataSourceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OcsOrderBizLoadComboDataSourceRequest request) throws Exception {
		NuroServiceProto.OcsOrderBizLoadComboDataSourceResponse.Builder response = NuroServiceProto.OcsOrderBizLoadComboDataSourceResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(request.getAColName().equalsIgnoreCase("doctor")){
			List<ComboListItemInfo> list = bas0270Repository.getOcsOrderBizLoadComboDataSourceListItem(hospCode, request.getAArgu2(), request.getAArgu1());
			if(!CollectionUtils.isEmpty(list)){
				for(ComboListItemInfo item : list){
					NuroModelProto.OcsOrderBizLoadComboDataSourceListItemInfo.Builder info = NuroModelProto.OcsOrderBizLoadComboDataSourceListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addResult(info);
				}
			}
		}else if(request.getAColName().equalsIgnoreCase("code")){
			List<ComboListItemInfo> listLayCombo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", request.getAArgu1(), getLanguage(vertx, sessionId));
			if(!CollectionUtils.isEmpty(listLayCombo)){
				for(ComboListItemInfo item : listLayCombo){
					NuroModelProto.OcsOrderBizLoadComboDataSourceListItemInfo.Builder info = NuroModelProto.OcsOrderBizLoadComboDataSourceListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addResult(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}