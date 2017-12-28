package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CPL0108U00InitGrdDetailListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00GrdDetailRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0108U00GrdDetailResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0108U00GrdDetailHandler extends ScreenHandler<CplsServiceProto.CPL0108U00GrdDetailRequest, CplsServiceProto.CPL0108U00GrdDetailResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0108U00GrdDetailHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0108U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0108U00GrdDetailRequest request)
					throws Exception {
			CplsServiceProto.CPL0108U00GrdDetailResponse.Builder response = CplsServiceProto.CPL0108U00GrdDetailResponse.newBuilder();
			Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
			List<CPL0108U00InitGrdDetailListItemInfo> listGrdDetail = cpl0109Repository.getListCPL0108U00GrdDetail(getHospitalCode(vertx, sessionId), request.getCodeType(),
					getLanguage(vertx, sessionId), startNum, CommonUtils.parseInteger(request.getOffset()));
		    if(listGrdDetail != null && !listGrdDetail.isEmpty()){
			    for(CPL0108U00InitGrdDetailListItemInfo item : listGrdDetail){
			    	CplsModelProto.CPL0108U00InitGrdDetailListItemInfo.Builder info = CplsModelProto.CPL0108U00InitGrdDetailListItemInfo.newBuilder();
				    if(!StringUtils.isEmpty(item.getCodeType())) {
				    	info.setCodeType(item.getCodeType());
				    }
				    if (!StringUtils.isEmpty(item.getCode())) {
				    	info.setCode(item.getCode());
				    }
				    if (!StringUtils.isEmpty(item.getCodeName())) {
				    	info.setCodeName(item.getCodeName());
				    }
				    if (!StringUtils.isEmpty(item.getCodeNameRe())) {
				    	info.setCodeNameRe(item.getCodeNameRe());
				    }
				    if (!StringUtils.isEmpty(item.getSystemGubun())) {
				    	info.setSystemGubun(item.getSystemGubun());
				    }
				    if (!StringUtils.isEmpty(item.getCodeValue())) {
				    	info.setCodeValue(item.getCodeValue());
				    }
				    response.addGrdDetail(info);
			    }
		    }
		return response.build();
	}
}
