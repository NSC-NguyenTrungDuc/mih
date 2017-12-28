package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintDateInfo;
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

import java.util.Date;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")
public class XRT1002U00LayPrintDateHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00LayPrintDateRequest, XrtsServiceProto.XRT1002U00LayPrintDateResponse> {
	private static final Log LOGGER = LogFactory.getLog(XRT1002U00LayPrintDateHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;

	@Override
	public boolean isValid(XrtsServiceProto.XRT1002U00LayPrintDateRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public XrtsServiceProto.XRT1002U00LayPrintDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00LayPrintDateRequest request) throws Exception {
		XrtsServiceProto.XRT1002U00LayPrintDateResponse.Builder response = XrtsServiceProto.XRT1002U00LayPrintDateResponse.newBuilder();
		Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
		Double fkOut1001 = CommonUtils.parseDouble(request.getFkout1001());
		Double pkocs = CommonUtils.parseDouble(request.getPkocs());
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<XRT1002U00LayPrintDateInfo> listPrintDate = ocs2003Repository.getXRT1002U00LayPrintDateInfo(getHospitalCode(vertx, sessionId), orderDate,request.getInOutGubun(),
				fkOut1001,request.getPrintOnly(),request.getJundalPart(), pkocs, fkinp1001);
		if(!CollectionUtils.isEmpty(listPrintDate)){
			for(XRT1002U00LayPrintDateInfo item : listPrintDate){
				XrtsModelProto.XRT1002U00LayPrintDateInfo.Builder info = XrtsModelProto.XRT1002U00LayPrintDateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPrintDateItem(info);
			}
		}
		return response.build();
	}
}