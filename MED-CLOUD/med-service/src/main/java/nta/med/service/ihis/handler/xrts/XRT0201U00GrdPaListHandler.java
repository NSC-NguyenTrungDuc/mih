package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdPaListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class XRT0201U00GrdPaListHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00GrdPaListRequest, XrtsServiceProto.XRT0201U00GrdPaListResponse> {
	private static final Log LOGGER = LogFactory.getLog(XRT0201U00GrdPaListHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;

	@Override
	public boolean isValid(XrtsServiceProto.XRT0201U00GrdPaListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if (!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public XrtsServiceProto.XRT0201U00GrdPaListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00GrdPaListRequest request) throws Exception {
		XrtsServiceProto.XRT0201U00GrdPaListResponse.Builder response = XrtsServiceProto.XRT0201U00GrdPaListResponse.newBuilder();
		//grdPaList
		List<XRT0201U00GrdPaListItemInfo> listGrdPaList = ocs0132Repository.getXRT0201U00GrdPaListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getIoGubun(), request.getActGubun(), request.getJundalTableCode(), request.getJundalPart(), request.getBunho(),
				DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD));
		if(!CollectionUtils.isEmpty(listGrdPaList)){
			for(XRT0201U00GrdPaListItemInfo item : listGrdPaList){
				XrtsModelProto.XRT0201U00GrdPaListItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdPaListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPaListItemInfo(info);
			}
		}
		return response.build();
	}
}