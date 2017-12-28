package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3024Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect2ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00ResultListQuerySelect2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00ResultListQuerySelect2Response;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0000Q00ResultListQuerySelect2Handler extends ScreenHandler<CplsServiceProto.CPL0000Q00ResultListQuerySelect2Request, CplsServiceProto.CPL0000Q00ResultListQuerySelect2Response> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00ResultListQuerySelect2Handler.class);
	@Resource
	private Cpl3024Repository cpl3024Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public CPL0000Q00ResultListQuerySelect2Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00ResultListQuerySelect2Request request) throws Exception {
        CplsServiceProto.CPL0000Q00ResultListQuerySelect2Response.Builder response = CplsServiceProto.CPL0000Q00ResultListQuerySelect2Response.newBuilder();
    	Double serial = CommonUtils.parseDouble(request.getSerial());
        List<CPL0000Q00ResultListQuerySelect2ListItemInfo> listItem = cpl3024Repository.getCPL0000Q00ResultListQuerySelect2(getHospitalCode(vertx, sessionId), request.getSpecimenSer(),
        		request.getKyunCode(), serial);
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00ResultListQuerySelect2ListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00ResultListQuerySelect2ListItemInfo.Builder info = CplsModelProto.CPL0000Q00ResultListQuerySelect2ListItemInfo.newBuilder();
        		if (item.getAntiSeq() != null) {
        			info.setAntiSeq(item.getAntiSeq().toString());
        		}
        		if (!StringUtils.isEmpty(item.getAntiName())) {
        			info.setAntiName(item.getAntiName());
        		}
        		if (!StringUtils.isEmpty(item.getMicName())) {
        			info.setMicName(item.getMicName());
        		}
        		if (!StringUtils.isEmpty(item.getMicResult())) {
        			info.setMicResult(item.getMicResult());
        		}

        		response.addResultList(info);
        	}
        }
		return response.build();
	}
}
