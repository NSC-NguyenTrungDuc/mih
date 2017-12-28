package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;




import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00CboJundalRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00CboJundalResponse;


@Service
@Scope("prototype")
public class CPL0001U00CboJundalHandler extends ScreenHandler<CPL0001U00CboJundalRequest, CPL0001U00CboJundalResponse>{
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0001U00CboJundalResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0001U00CboJundalRequest request)
			throws Exception {
		CPL0001U00CboJundalResponse.Builder response = CPL0001U00CboJundalResponse.newBuilder();
		List<ComboListItemInfo> list =  cpl0109Repository.getCPL0001U00CboJundalInfo(getHospitalCode(vertx, sessionId), "01", "CPL", getLanguage(vertx, sessionId));
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
