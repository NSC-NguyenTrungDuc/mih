package nta.med.service.ihis.handler.schs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch3100;
import nta.med.core.domain.sch.Sch3101;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3100Repository;
import nta.med.data.dao.medi.sch.Sch3101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00BtnMake2SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH3001U00BtnMake2SaveLayoutHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00BtnMake2SaveLayoutRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(SCH3001U00BtnMake2SaveLayoutHandler.class);
	@Resource
	private Sch3100Repository sch3100Repository;
	
	@Resource
	private Sch3101Repository sch3101Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00BtnMake2SaveLayoutRequest request) throws Exception {
			LOGGER.info(request.toString());
            SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
            String hospCode = getHospitalCode(vertx, sessionId);
        	List<SchsModelProto.SCH3001U00GrdSCH3100Info> listSch3100Item = request.getGrdSch3100InfoList();
        	if (!CollectionUtils.isEmpty(listSch3100Item)) {
				for (SchsModelProto.SCH3001U00GrdSCH3100Info item : listSch3100Item) {
					Date reserDate = null;
					if(!StringUtils.isEmpty(item.getReserDate())){
						reserDate = DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD);
					}
					if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
						Sch3100 sch3100 = new Sch3100();
						sch3100.setSysDate(new Date());
						sch3100.setSysId(request.getSysId());
						sch3100.setUpdDate(new Date());
						sch3100.setUpdId(request.getSysId());
						sch3100.setHospCode(hospCode);
						sch3100.setJundalTable(item.getJundalTable());
						sch3100.setJundalPart(item.getJundalPart());
						sch3100.setGumsaja(item.getGumsaja());
						sch3100.setReserYn(item.getReserYn());
						sch3100.setReserDate(reserDate);
						sch3100Repository.save(sch3100);
					} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
						sch3100Repository.updateXSavePerformerCase4(request.getSysId(), new Date(), item.getReserYn(),
								hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate);
					} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
						sch3100Repository.deleteXSavePerformerCase4(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate);
					}
				}
        	}
        	
        	//
        	List<SchsModelProto.SCH3001U00GrdSCH3101Info> listSch3101Item = request.getGrdSch3101InfoList();
        	if (!CollectionUtils.isEmpty(listSch3101Item)) {
				for (SchsModelProto.SCH3001U00GrdSCH3101Info item : listSch3101Item) {
					Date reserDate = null;
					Double inwon = null;
					Double addInwon = null;
					if(!StringUtils.isEmpty(item.getReserDate())){
						reserDate = DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD);
					}
					if(!StringUtils.isEmpty(item.getIwon())){
						inwon = CommonUtils.parseDouble(item.getIwon());
					}
					if(!StringUtils.isEmpty(item.getAddIwon())){
						addInwon = CommonUtils.parseDouble(item.getAddIwon());
					}
					if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
						Sch3101 Sch3101 = new Sch3101();
						Sch3101.setSysDate(new Date());
						Sch3101.setSysId(request.getSysId());
						Sch3101.setUpdDate(new Date());
						Sch3101.setUpdId(request.getSysId());
						Sch3101.setHospCode(hospCode);
						Sch3101.setJundalTable(item.getJundalTable());
						Sch3101.setJundalPart(item.getJundalPart());
						Sch3101.setGumsaja(item.getGumsaja());
						Sch3101.setReserDate(reserDate);
						Sch3101.setStartTime(item.getStartTime());
						Sch3101.setEndTime(item.getEndTime());
						Sch3101.setInwon(inwon);
						Sch3101.setAddInwon(addInwon);
						sch3101Repository.save(Sch3101);
					} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
						sch3101Repository.updateXSavePerformerCase5(request.getSysId(), new Date(), item.getEndTime(), inwon, addInwon,
								hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate, item.getStartTime());
					} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
						sch3101Repository.deleteXSavePerformerCase5(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate, item.getStartTime());
					}
				}
        	}
        	
        	response.setResult(true);
        	return response.build();
	}
}
