package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CPL0101U00InitListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00InitRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00InitResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0101U00InitHandler extends ScreenHandler<CplsServiceProto.CPL0101U00InitRequest, CplsServiceProto.CPL0101U00InitResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00InitHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0101U00InitResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0101U00InitRequest request)
					throws Exception {
		CplsServiceProto.CPL0101U00InitResponse.Builder response = CplsServiceProto.CPL0101U00InitResponse.newBuilder();
		String offset = null;
		Integer startNum = null;
		if(!StringUtils.isEmpty(request.getPageNumber())){
			offset = request.getOffset();
		  	startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		}
		List<CPL0101U00InitListItemInfo> listResult  = cpl0109Repository.getInitListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getTxtHangmog(), request.getIoGubun(), startNum, CommonUtils.parseInteger(offset));
		if(listResult != null && !listResult.isEmpty()){
	    	 for(CPL0101U00InitListItemInfo item : listResult){
				CplsModelProto.CPL0101U00InitListItemInfo.Builder info = CplsModelProto.CPL0101U00InitListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInitInfo(info);
			}
		}
		return response.build();
	}
}
