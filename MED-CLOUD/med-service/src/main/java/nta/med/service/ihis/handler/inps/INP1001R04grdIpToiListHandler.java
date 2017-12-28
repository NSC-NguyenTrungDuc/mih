package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001R04grdIpToiListInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001R04grdIpToiListRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001R04grdIpToiListResponse;

@Service
@Scope("prototype")
public class INP1001R04grdIpToiListHandler extends ScreenHandler<InpsServiceProto.INP1001R04grdIpToiListRequest, InpsServiceProto.INP1001R04grdIpToiListResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001R04grdIpToiListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001R04grdIpToiListRequest request) throws Exception {
		InpsServiceProto.INP1001R04grdIpToiListResponse.Builder response = InpsServiceProto.INP1001R04grdIpToiListResponse.newBuilder();
		Date fromDate = DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getToDate(),DateUtil.PATTERN_YYMMDD);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<INP1001R04grdIpToiListInfo> listGrd = inp1001Repository.getINP1001R04grdIpToiListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getHoDong(), fromDate, toDate, startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listGrd)){
			for (INP1001R04grdIpToiListInfo item : listGrd) {
				InpsModelProto.INP1001R04grdIpToiListInfo.Builder info = InpsModelProto.INP1001R04grdIpToiListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdIpToiList(info);
			}
		}
		return response.build();
	}

}
