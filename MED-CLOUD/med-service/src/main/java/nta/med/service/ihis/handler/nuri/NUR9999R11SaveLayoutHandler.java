package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur9999;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur9999Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR9999R11SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR9999R11SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur9999Repository nur9999Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR9999R11grdNUR9999Info> infos = request.getGrdnur9999InfoList();
		for (NuriModelProto.NUR9999R11grdNUR9999Info info : infos) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur9999 nur9999 = new Nur9999();
				nur9999.setSysId(userId);
				nur9999.setSysDate(sysDate);
				nur9999.setUpdId(userId);
				nur9999.setUpdDate(sysDate);
				nur9999.setHospCode(hospCode);
				nur9999.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur9999.setPknur9999(CommonUtils.parseDouble(info.getPknur9999()));
				nur9999.setGubun(info.getGubun());
				nur9999.setWriteDate(DateUtil.toDate(info.getWriteDate(), DateUtil.PATTERN_YYMMDD));
				nur9999.setBunho(info.getBunho());
				nur9999.setSuname(info.getSuname());
				nur9999.setBirth(DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD));
				nur9999.setAge(info.getAge());
				nur9999.setGwa(info.getGwa());
				nur9999.setDoctor(info.getDoctor());
				nur9999.setReason(info.getReason());
				nur9999.setAddress(info.getAddress());
				nur9999.setIpwonDate(DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
				nur9999.setToiwonDate(DateUtil.toDate(info.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
				nur9999.setHoDong(info.getHoDong());
				nur9999.setDamdangNurse(info.getDamdangNurse());
				nur9999.setLeaderNurse(info.getLeaderNurse());
				nur9999.setTel(info.getTel());
				nur9999.setSangName(info.getSangName());
				nur9999.setPastHis(info.getPastHis());
				nur9999.setKey1Relation(info.getKey1Relation());
				nur9999.setKey1Home(info.getKey1Home());
				nur9999.setKey1Phone(info.getKey1Phone());
				nur9999.setKey1Office(info.getKey1Office());
				nur9999.setKey2Relation(info.getKey2Relation());
				nur9999.setKey2Home(info.getKey2Home());
				nur9999.setKey2Phone(info.getKey2Phone());
				nur9999.setKey2Office(info.getKey2Office());
				nur9999.setInfection(info.getInfection());
				nur9999.setTaboo(info.getTaboo());
				nur9999.setInpatientCourse(info.getInpatientCourse());
				nur9999.setNursingPass(info.getNursingPass());
				nur9999.setContinueNursing(info.getContinueNursing());
				nur9999.setFood(info.getFood());
				nur9999.setFoodAdl(info.getFoodAdl());
				nur9999.setFoodAdlCmt(info.getFoodAdlCmt());
				nur9999.setExcretion(info.getExcretion());
				nur9999.setExcretionAdl(info.getExcretionAdl());
				nur9999.setExcretionAdlCmt(info.getExcretionAdlCmt());
				nur9999.setMove(info.getMove());
				nur9999.setMoveAdl(info.getMoveAdl());
				nur9999.setMoveAdlCmt(info.getMoveAdlCmt());
				nur9999.setWash(info.getWash());
				nur9999.setWashAdl(info.getWashAdl());
				nur9999.setWashAdlCmt(info.getWashAdlCmt());
				nur9999.setWareAdl(info.getWareAdl());
				nur9999.setWareAdlCmt(info.getWareAdlCmt());
				nur9999.setCommunication(info.getCommunication());
				nur9999.setSleep(info.getSleep());
				nur9999.setTube(info.getTube());
				nur9999.setComments(info.getComments());
				
				nur9999Repository.save(nur9999);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur9999> nurs = nur9999Repository.findByHospCodePknur9999(hospCode,
						CommonUtils.parseDouble(info.getPknur9999()));
				
				if(!CollectionUtils.isEmpty(nurs)){
					Nur9999 nur9999 = nurs.get(0);
					
					nur9999.setUpdId(userId);
					nur9999.setUpdDate(sysDate);
					nur9999.setGubun(info.getGubun());
					nur9999.setWriteDate(DateUtil.toDate(info.getWriteDate(), DateUtil.PATTERN_YYMMDD));
					nur9999.setBunho(info.getBunho());
					nur9999.setSuname(info.getSuname());
					nur9999.setBirth(DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD));
					nur9999.setAge(info.getAge());
					nur9999.setGwa(info.getGwa());
					nur9999.setDoctor(info.getDoctor());
					nur9999.setReason(info.getReason());
					nur9999.setAddress(info.getAddress());
					nur9999.setIpwonDate(DateUtil.toDate(info.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
					nur9999.setToiwonDate(DateUtil.toDate(info.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
					nur9999.setHoDong(info.getHoDong());
					nur9999.setDamdangNurse(info.getDamdangNurse());
					nur9999.setLeaderNurse(info.getLeaderNurse());
					nur9999.setTel(info.getTel());
					nur9999.setSangName(info.getSangName());
					nur9999.setPastHis(info.getPastHis());
					nur9999.setKey1Relation(info.getKey1Relation());
					nur9999.setKey1Home(info.getKey1Home());
					nur9999.setKey1Phone(info.getKey1Phone());
					nur9999.setKey1Office(info.getKey1Office());
					nur9999.setKey2Relation(info.getKey2Relation());
					nur9999.setKey2Home(info.getKey2Home());
					nur9999.setKey2Phone(info.getKey2Phone());
					nur9999.setKey2Office(info.getKey2Office());
					nur9999.setInfection(info.getInfection());
					nur9999.setTaboo(info.getTaboo());
					nur9999.setInpatientCourse(info.getInpatientCourse());
					nur9999.setNursingPass(info.getNursingPass());
					nur9999.setContinueNursing(info.getContinueNursing());
					nur9999.setFood(info.getFood());
					nur9999.setFoodAdl(info.getFoodAdl());
					nur9999.setFoodAdlCmt(info.getFoodAdlCmt());
					nur9999.setExcretion(info.getExcretion());
					nur9999.setExcretionAdl(info.getExcretionAdl());
					nur9999.setExcretionAdlCmt(info.getExcretionAdlCmt());
					nur9999.setMove(info.getMove());
					nur9999.setMoveAdl(info.getMoveAdl());
					nur9999.setMoveAdlCmt(info.getMoveAdlCmt());
					nur9999.setWash(info.getWash());
					nur9999.setWashAdl(info.getWashAdl());
					nur9999.setWashAdlCmt(info.getWashAdlCmt());
					nur9999.setWareAdl(info.getWareAdl());
					nur9999.setWareAdlCmt(info.getWareAdlCmt());
					nur9999.setCommunication(info.getCommunication());
					nur9999.setSleep(info.getSleep());
					nur9999.setTube(info.getTube());
					nur9999.setComments(info.getComments());
					
					nur9999Repository.save(nur9999);
				}
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				nur9999Repository.DELETEByHospCodePknur9999(hospCode, CommonUtils.parseDouble(info.getPknur9999()));
			}
		}

		response.setResult(true);
		return response.build();
	}

}

