package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.inps.INP2004Q00grdINP2004Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q00grdINP2004Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q00grdINP2004Response;

@Service
@Scope("prototype")
public class INP2004Q00grdINP2004Handler extends ScreenHandler<InpsServiceProto.INP2004Q00grdINP2004Request, InpsServiceProto.INP2004Q00grdINP2004Response>{
	@Resource
	Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2004Q00grdINP2004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2004Q00grdINP2004Request request) throws Exception {
		InpsServiceProto.INP2004Q00grdINP2004Response.Builder response = InpsServiceProto.INP2004Q00grdINP2004Response.newBuilder();
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode))
			hospCode = getHospitalCode(vertx, sessionId);
		List<INP2004Q00grdINP2004Info> list = inp2004Repository.getListINP2004Q00grdINP2004Info(hospCode, request.getHoDong(), request.getHoCode(), request.getFromDate(), request.getToDate());
		if (!CollectionUtils.isEmpty(list)) {
			for (INP2004Q00grdINP2004Info item : list) {
				InpsModelProto.INP2004Q00grdINP2004Info.Builder info = InpsModelProto.INP2004Q00grdINP2004Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkinp1001() != null)
					info.setPkinp1001(CommonUtils.parseString(item.getPkinp1001()));
				if (item.getAge() != null)
					info.setAge(CommonUtils.parseString(item.getAge()));
				if (item.getBirth() != null)
					info.setBirth(DateUtil.toString(item.getBirth(), DateUtil.PATTERN_YYMMDD));
				if (info.getIpwonDate() != null)
					info.setIpwonDate(DateUtil.toString(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
				if (info.getToiwonDate() != null)
					info.setToiwonDate(DateUtil.toString(item.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
				if (info.getOrderDate() != null)
					info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
