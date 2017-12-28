package nta.med.service;

import com.google.protobuf.Message;
import nta.med.core.domain.event.BookingEvent;
import nta.med.core.domain.event.HospitalEvent;
import nta.med.core.domain.event.PatientEvent;
import nta.med.core.domain.event.vo.*;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.store.EventStore;
import nta.med.core.utils.BeanUtils;
import nta.med.data.mongo.medi.BookingEventRepository;
import nta.med.data.mongo.medi.HospitalEventRepository;
import nta.med.data.mongo.medi.PatientEventRepository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.function.BiFunction;
import java.util.function.Supplier;

/**
 * @author dainguyen.
 */
@Service("eventStore")
public class EventStoreImpl implements EventStore {

    @Resource
    private HospitalEventRepository hospitalEventRepository;

    @Resource
    private PatientEventRepository patientEventRepository;

    @Resource
    private BookingEventRepository bookingEventRepository;

    @Override
    public Message persist(Message event, BiFunction<String, Supplier<Long>, Long> counterFunc) {
        if(event instanceof NuroServiceProto.PatientEvent) {
            NuroServiceProto.PatientEvent p = (NuroServiceProto.PatientEvent)event;
            PatientEvent eventPo = toPatientPo(p);
            PatientEvent evt = patientEventRepository.findFirstByOrderByIdDesc();
            eventPo.setId(counterFunc.apply("PATIENT_EVENTS", () -> evt == null ? 1 : evt.getId()));
            eventPo.setTimestamp(System.nanoTime());
            patientEventRepository.save(eventPo);
            return p.toBuilder().setId(eventPo.getId()).setTimestamp(eventPo.getTimestamp()).build();
        }
        else if(event instanceof NuroServiceProto.BookingEvent)
        {
            NuroServiceProto.BookingEvent p = (NuroServiceProto.BookingEvent)event;
            BookingEvent eventPo = toBookingPo(p);
            BookingEvent evt = bookingEventRepository.findFirstByOrderByIdDesc();
            eventPo.setId(counterFunc.apply("BOOKING_EVENTS", () -> evt == null ? 1 : evt.getId()));

            eventPo.setTimestamp(System.nanoTime());
            bookingEventRepository.save(eventPo);
            return p.toBuilder().build();
        }
        else if(event instanceof NuroServiceProto.HospitalEvent)
        {
            NuroServiceProto.HospitalEvent p = (NuroServiceProto.HospitalEvent)event;
            HospitalEvent eventPo = toHospitalPo(p);
            HospitalEvent evt = hospitalEventRepository.findFirstByOrderByIdDesc();
            eventPo.setId(counterFunc.apply("HOSPITAL_EVENTS", () -> evt == null ? 1 : evt.getId()));

            eventPo.setTimestamp(System.nanoTime());
            hospitalEventRepository.save(eventPo);
            return p.toBuilder().build();
        }

        return event;
    }

    private HospitalEvent toHospitalPo(NuroServiceProto.HospitalEvent p) {
        HospitalEvent r = new HospitalEvent();
        if(p != null)
        {
            BeanUtils.copyProperties(p, r, Language.JAPANESE.toString());
        }
        DoctorScheduleVo doctorScheduleVo = new DoctorScheduleVo();
        BeanUtils.copyProperties(p.getSchedules(), doctorScheduleVo, Language.JAPANESE.toString());
        r.setSchedules(doctorScheduleVo);
        for(NuroModelProto.Department department : p.getDeptsList())
        {
            DepartmentVo departmentVo = new DepartmentVo();
            BeanUtils.copyProperties(department, departmentVo, Language.JAPANESE.toString());
            r.getDepts().add(departmentVo);
        }
        return r;

    }

    private BookingEvent toBookingPo(NuroServiceProto.BookingEvent p) {
        BookingEvent r = new BookingEvent();
        if(p != null)
        {
            BeanUtils.copyProperties(p, r, Language.JAPANESE.toString());
        }
        return r;
    }

    private PatientEvent toPatientPo(NuroServiceProto.PatientEvent p) {
        PatientEvent r = new PatientEvent();
        BeanUtils.copyProperties(p, r, Language.JAPANESE.toString());
        AcceptInformationVo acceptInformationVo = new AcceptInformationVo();
        BeanUtils.copyProperties(p.getAcceptInfo(), acceptInformationVo, Language.JAPANESE.toString());

        for(NuroModelProto.NuroOUT0101U02GridGongbiListInfo nuroOUT0101U02GridGongbiListInfo : p.getPrivateInsuranceList())
        {
            PrivateInsuranceVo privateInsuranceVo = new PrivateInsuranceVo();
            BeanUtils.copyProperties(nuroOUT0101U02GridGongbiListInfo, privateInsuranceVo, Language.JAPANESE.toString());
            r.getPrivateInsuranceVos().add(privateInsuranceVo);
        }

        for(NuroModelProto.NuroOUT0101U02GridBoheomInfo nuroOUT0101U02GridBoheomInfo : p.getPublicInsuranceList())
        {
            PublicInsuranceVo publicInsuranceVo = new PublicInsuranceVo();
            BeanUtils.copyProperties(nuroOUT0101U02GridBoheomInfo, publicInsuranceVo, Language.JAPANESE.toString());
            r.getPublicInsuranceVos().add(publicInsuranceVo);
        }

        r.setAcceptInfo(acceptInformationVo);
        return r;
    }
}
