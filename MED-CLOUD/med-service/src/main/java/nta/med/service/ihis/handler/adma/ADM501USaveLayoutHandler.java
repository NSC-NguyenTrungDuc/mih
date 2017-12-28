package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.adm.Adm0002;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADM501UListItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class ADM501USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM501USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM501USaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Adm0002Repository adm0002Repository;

	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM501USaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = null;
		try {
			for (ADM501UListItemInfo info : request.getListItemInfoList()) {
				if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
					insertAdm0002(info, request.getUserInfo());
					result = 1;
				} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
					Double adm0002Pk = CommonUtils.parseDouble(info.getAdm0002Pk());
					result = adm0002Repository.updateAdm0002(info.getMsgGubun(), info.getKoreaMsg(),
							info.getJapanMsg(), info.getSpeakMsg(), adm0002Pk);
				} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
					Double adm0002Pk = CommonUtils.parseDouble(info.getAdm0002Pk());
					result = adm0002Repository.deleteAdm0002(adm0002Pk);
				}
			}
			return null;
		}finally {
			response.setResult(!StringUtils.isEmpty(result));
		}
	}

	private void insertAdm0002(ADM501UListItemInfo info, String userId){
		Adm0002 adm0002 = new Adm0002();
		Double adm0002Pk = CommonUtils.parseDouble(info.getAdm0002Pk());
		adm0002.setAdm0002Pk(adm0002Pk);
		adm0002.setMsgGubun(info.getMsgGubun());
		adm0002.setKoreaMsg(info.getKoreaMsg());
		adm0002.setJapanMsg(info.getJapanMsg());
		adm0002.setSpeakMsg(info.getSpeakMsg());
		adm0002Repository.save(adm0002);
	}
}