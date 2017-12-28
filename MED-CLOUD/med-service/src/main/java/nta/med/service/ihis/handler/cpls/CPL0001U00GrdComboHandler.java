package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdComboRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0001U00GrdComboHandler  extends ScreenHandler<CplsServiceProto.CPL0001U00GrdComboRequest, CplsServiceProto.CPL0001U00GrdComboResponse> {

	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0001U00GrdComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0001U00GrdComboRequest request)
			throws Exception {
		CPL0001U00GrdComboResponse.Builder response = CPL0001U00GrdComboResponse.newBuilder();
		
		List<ComboListItemInfo> list = cpl0109Repository.getCPL0001U00GrdComboInfo(getHospitalCode(vertx, sessionId), "01", "CPL", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CplsModelProto.CPL0001U00GrdComboInfo.Builder info = CplsModelProto.CPL0001U00GrdComboInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeNameRe(item.getCodeName());
				}
				response.addDt(info);
			}
		}
		return response.build();
	}

}
